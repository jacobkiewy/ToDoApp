using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string Message = "Bu Bir Mesaj";
        public static string AuthorizationDenied = "Yetki Yok!";
        public static string ToDoListed = "ToDo Listelendi";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserNotFound = "Kullanıcı Bulunamadı!";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        public static string PasswordError = "Parola Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserRegistered = "Kullanıcı Kaydı Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Zaten Var";
        public static string ToDoAdded = "ToDo Eklendi";
        public static string ToDoDeleted = "ToDo Silindi";
        public static string ToDoUpdated = "ToDo Güncellendi";
        public static string GetAllDetails = "Bütün Veriler Listelendi";
        public static string UsersListed = "Kullanıcılar Listelendi";
        public static string AddedFeedBack = "Geri Bildirim Gönderildi. Teşekkürler!";
        public static string DeletedFeedBack = "FeedBack Silindi";
        public static string ListedFeedBack = "FeedBacks Listelendi";
        public static string UserBanned = "Giriş Engellendi";

        //FluentValidation Message
        public static string ToDoTitleNotEmpty = "Başlığın Boş Olamaz";
        public static string ToDoDescriptionNotEmpty = "Açıklama Boş Olamaz";
        public static string ToDoListedMaxLength = "Uzunluk Maksimum 75 Olmalı";
        public static string ToDoListedMinLength = "Uzunluk Minimum 5 Olmalı";
        public static string EmailNotEmpty = "Email Boş Olamaz";
        public static string NotEmail = "Lütfen Email Adresi Giriniz";
        public static string LastNameMustNotBeEmpty = "Soyisim Boş Olamaz";
        public static string FirstNameMustNotBeEmpty = "İsim Boş Olamaz";
        public static string PasswordMustNotBeEmpty = "Şifre Boş Olamaz";
        public static string PasswordQualityControl = "Şifreniz: 'Büyük Küçük Harf ve Rakam' İçermelidir!";
        public static string PasswordMinLengthError = "Şifreniz En Az 6 Karakter Olmalı";
        
    }
}
