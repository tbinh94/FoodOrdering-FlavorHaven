using Food_DL;
using Food_DTO;
using System.Collections.Generic;

namespace Food_BL
{
    public class AdItemBL
    {
        public int Id { get; set; }
        public string AdName { get; set; }
        public string AdDescription { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string DiscountText { get; set; }
        public string Address { get; set; }

        // Phương thức chuyển đổi từ AdItemDTO sang AdItemBL
        public static AdItemBL FromDTO(AdItemDTO adItemDTO)
        {
            return new AdItemBL
            {
                Id = adItemDTO.Id,
                AdDescription = adItemDTO.AdDescription,
                Image = adItemDTO.Image,
            };
        }

        // Phương thức để lấy tất cả quảng cáo (có thể gọi từ lớp DL)
        public List<AdItemDTO> GetAllAds()
        {
            AdItemDL adItemDL = new AdItemDL();
            return adItemDL.GetAllAdsFromDatabase();
        }
    }

}
