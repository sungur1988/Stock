using Core.EntityLayer.Concrete.AuthorizationEntities;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarılı bir şekilde eklendi.";
        public static string CategoryAdded = "Kategori başarılı bir şekilde eklendi.";
        public static string CategoryDeleted = "Kategori başarılı bir şekilde silindi.";
        public static string CategoryUpdated = "Kategori başarılı bir şekilde güncellendi.";
        public static string ProductListed = "Ürünler listelendi.";
        public static string ProductDeleted = "Ürün başarılı bir şekilde silindi.";
        public static string ProductUpdated = "Ürün başarılı bir şekilde güncellendi.";
        public static string CategoryListed = "Kategoriler listelendi.";
        public static string ProductMovementAdded = "Ürün hareketi başarılı bir şekilde eklendi.";
        public static string ProductMovementListed = "Ürün hareketleri listelendi.";
        public static string AuthorizationDenied = "Bu işlem için yetkiniz yok.";
        public static string StockTotalListed= "Stoklar listelendi ";
        public static string DifferentUserAddedCategory = "Bu kategori başka bir kullanıcı tarafından eklenmiştir.Silme yetkiniz yoktur.";
        public static string ProductExistInThisCategory = "Bu kategoriye ait ürün bulunduğundan bu kategori silinemez.";
        public static string ProductMovementExistWithThisProduct = "Bu ürüne ait stok hareketleri olduğu için bu ürün silinemez.";
        public static string UserAlreadyExist = "Bu email adresine ait bir kullanıcı bulunmaktadır";
        public static string UserNotFound = "Bu email adresine sahip bir kullanıcı bulunamadı";
        public static string PasswordError ="Şifreniz yanlış girilmiştir.";
        public static string SuccessfulLogin = "Başarılı bir şekilde giriş yapıldı.";
        public static string UserRegistered = "Kullanıcı başarılı bir şekilde kaydedildi.";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu.";
        public static string UsersListed = "Tüm kullanıcılar listelendi";
        public static string CategoryNotFound = "Bu Id'ye ait kategori bulunamamıştır. ";
        public static string ProductNotFound = "Bu Id'ye ait ürün bulunamamıştır. ";
        public static string ProductMovementNotFound = "Bu Id'ye ait ürün hareketi bulunamamıştır.";
    }
}
