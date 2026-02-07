using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    //Ben bunu sürekli new'lemeyeyim diye static yaptım
    public static class Messages
    {
        public static string RealEstateAdded = "Taşınmaz başarıyla eklendi";
        public static string RealEstateNameInvalid = "Geçersiz taşınmaz ismi";
        public static string NoRealEstate = "Taşınmaz bulunamadı";
        public static string RealEstateDeleted = "Taşınmaz başarıyla silindi";
        public static string NoRealEstateUpdated = "Güncellenecek taşınmaz bulunamadı";
        public static string RealEstateUpdated = "Taşınmaz başarıyla güncellendi";
        public static string IsThereParcelAndLotNumber = "Bu parsel ve ada numarasına sahip taşınmaz zaten mevcut";
        public static string RealEstateListed = "Taşınmazlar ilçeye göre listelendi";
        public static string RealEstateIdListed = "Taşınmaz Id'ye göre listelendi";
        public static string RealEstateNeighborIdListed = "Taşınmaz mahalleye göre listelendi";
        public static string CityAdded = "Şehir başarıyla eklendi";
        public static string CityDeleted = "Şehir başarıyla silindi";
        public static string CityUpdated = "Şehir başarıyla güncellendi";
        public static string CityNotFound = "Şehir bulunamadı";
        public static string CityListed = "Şehirler Listelendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string DistrictAdded = "İlçe Eklendi";
        public static string DistrictUpdated = "İlçe Güncellendi";
        public static string DistrictDeleted = "İlçe Silindi.";
        public static string DistrictNotFound = "İlçe Bulunamadı.";
        public static string DistrictListed = "İlçe Bulunamadı.";
        public static string NeighborhoodListed = "Mahalle Listelendi.";
        public static string NeighborhoodAdded = "Mahalle Eklendi.";
        public static string NeighborhoodUpdated = "Mahalle Güncellendi.";
        public static string NeighborhoodDeleted = "Mahalle Güncellendi.";
        public static string NeighborhoodNotFound = "Mahalle Güncellendi.";
        public static string LogMessage = "Veritabanına loglandı.";
        public static string FileLogMessage = "Dosyaya loglandı.";
        public static string AuditLogError = "Hiçbir kayıt kriterlere uymamaktadır.";
        public static string OperationTypeArea = "Geçersiz operayon tipi";
        public static string AreaProcess = "İşlem sonucu boş(Bir kesişim bulunamadı)";
        public static string NewAnalysis = "Yeni Analiz Kontrolü";
        public static string SuccessAnalysis = "Yeni Analiz Kontrolü";
        public static string IntersectionNoSave = "Kesişim hesaplandı(Kaydedilmedi).";
        public static string RecordNotFound = "Aranılan kayıt bulunamadı";
        public static string DeleteAnaliysis = "Aranılan kayıt bulunamadı";
        public static string AreaAnalysisUpdate = "Alan analizi güncellemesi başarılı.";
        public static string MissingProcess = "Lütfen A, B ve C geometrilerini tamamlayın.";
        public static string AnalysisMessage = "Analiz Sonucu";
        public static string UnionAB = "Geometry D";
        public static string UnionABC = "GEometry E";
        public static string FalseProcess = "Geçersiz işlem türü";
        public static string NoIntersection = "Hiçbir kesişim noktası bulunamadı.";
        public static string SaveAnalysis = "başarıyla keydeildi.";
        public static string IntersectionResult = "Kesişim sonucu hesaplandı (sadece görsel).";
    }
}
