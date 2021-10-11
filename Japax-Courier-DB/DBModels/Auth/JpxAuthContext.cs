using System;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Japax_Courier_DB.DBModels.Auth
{
    public partial class JpxAuthContext : DbContext
    {
        public JpxAuthContext()
        {
        }

        public JpxAuthContext(DbContextOptions<JpxAuthContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JpxErrorLog> JpxErrorLog { get; set; }
        public virtual DbSet<JpxUserLoginInfo> JpxUserLoginInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=JPX_USER_AUTHENTICATION;integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<JpxErrorLog>(entity =>
            {
                entity.HasKey(e => e.ErrId);

                entity.ToTable("JPX_ERROR_LOG");

                entity.Property(e => e.ErrId).HasColumnName("ERR_ID");

                entity.Property(e => e.ErrEntity)
                    .HasColumnName("ERR_ENTITY")
                    .HasMaxLength(4000);

                entity.Property(e => e.ErrInnerException)
                    .HasColumnName("ERR_INNER_EXCEPTION")
                    .HasMaxLength(4000)
                    .HasComment("C# exception handling during the execution of a program");

                entity.Property(e => e.ErrLineNo)
                    .HasColumnName("ERR_LINE_NO")
                    .HasComment("returns the line number at which an error occurred.");

                entity.Property(e => e.ErrMessage)
                    .HasColumnName("ERR_MESSAGE")
                    .HasMaxLength(4000)
                    .HasComment("returns the message text of the error that caused the error (database generated message) ");

                entity.Property(e => e.ErrMethod)
                    .HasColumnName("ERR_METHOD")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("returns the event name at which an error occurred.");

                entity.Property(e => e.ErrMethodPayload)
                    .HasColumnName("ERR_METHOD_PAYLOAD")
                    .HasMaxLength(4000)
                    .HasComment("Input data, which caused an error due to data entry");

                entity.Property(e => e.ErrNo)
                    .HasColumnName("ERR_NO")
                    .HasComment("returns the error number that caused the error. ");

                entity.Property(e => e.ErrProcedure)
                    .HasColumnName("ERR_PROCEDURE")
                    .HasMaxLength(128)
                    .HasComment("returns the name of the Stored Procedure or trigger of where an error occurred.");

                entity.Property(e => e.ErrRaisedDate)
                    .HasColumnName("ERR_RAISED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ErrStackTrace)
                    .HasColumnName("ERR_STACK_TRACE")
                    .HasMaxLength(4000)
                    .HasComment("line number in the method where the exception occurs in front-end");

                entity.Property(e => e.ErrStatus)
                    .HasColumnName("ERR_STATUS")
                    .HasComment("0=Pending  1=Error Solved");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");
            });

            modelBuilder.Entity<JpxUserLoginInfo>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.ToTable("JPX_USER_LOGIN_INFO");

                entity.HasIndex(e => e.UserMobileNo)
                    .HasName("IX_JPX_USER_LOGIN_INFO")
                    .IsUnique();

                entity.Property(e => e.LoginId)
                    .HasColumnName("LOGIN_ID")
                    .HasComment("During registration Login ID will be insert into JPX_COURIER_DB table JCD_SENDER_INFO column SENDER_ID");

                entity.Property(e => e.ActiveStatus)
                    .HasColumnName("ACTIVE_STATUS")
                    .HasComment("1=Active  0=Inactive");

                entity.Property(e => e.CourierApp)
                    .HasColumnName("COURIER_APP")
                    .HasComment("0=Not Using This App  1=Using This App");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("DEVICE_ID")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasComment("IMEI");

                entity.Property(e => e.DeviceType)
                    .HasColumnName("DEVICE_TYPE")
                    .HasComment("0=Android 1=iPhone");

                entity.Property(e => e.FcmToken)
                    .IsRequired()
                    .HasColumnName("FCM_TOKEN")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("FCM (Firebase Cloud Messaging) or Registration Token from Google Cloud Messaging");

                entity.Property(e => e.ProfilePicture)
                    .HasColumnName("PROFILE_PICTURE")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Image Location in Web Folder with Login ID/Sender ID");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("REGISTRATION_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.RideshareApp)
                    .HasColumnName("RIDESHARE_APP")
                    .HasComment("0=Not Using This App  1=Using This App");

                entity.Property(e => e.SecretKey)
                    .IsRequired()
                    .HasColumnName("SECRET_KEY")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.SetDate)
                    .HasColumnName("SET_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserEmail)
                    .HasColumnName("USER_EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasColumnName("USER_FIRST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasColumnName("USER_LAST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserMobileNo)
                    .IsRequired()
                    .HasColumnName("USER_MOBILE_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
