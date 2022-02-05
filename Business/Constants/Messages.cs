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
    }
}
