using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPINetCore.Entities
{
    public class DMTINH
    {
        [Key]
        public string MA { get; set; }
        public string TEN { get; set; }
        public int CAP { get; set; }
        public string NSD { get; set; }
        public DateTime NGAYNHAP { get; set; }
    }

    public class DMHUYEN
    {
        [Key]
        public string MA { get; set; }
        public string TEN { get; set; }
        public int CAP { get; set; }
        public string NSD { get; set; }
        public DateTime NGAYNHAP { get; set; }
        public string MATINH { get; set; }
    }

    public class DMPHUONGXA
    {
        [Key]
        public string MA { get; set; }
        public string TEN { get; set; }
        public int CAP { get; set; }
        public string NSD { get; set; }
        public DateTime NGAYNHAP { get; set; }
        public string MAHUYEN { get; set; }
        public string MATINH { get; set; }
    }
    public class DMDANTOC
    {
        [Key]
        public string MA { get; set; }
        [Required]
        public string TEN_DANTOC { get; set; }
        public string TEN_KHAC { get; set; }
        [Required]
        [DefaultValue(1)]
        public int TRANGTHAI { get; set; }
    }

    public class DMTONGIAO
    {
        [Key]
        public string MA { get; set; }
        [Required]
        public string TEN { get; set; }
        [Required]
        [DefaultValue(1)]
        public int TRANGTHAI { get; set; }
    }

    public class DMHOCVAN
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string TEN { get; set; }
        public string MOTA { get; set; }
        [DefaultValue(1)]
        public int THUTU { get; set; }
        [Required]
        [DefaultValue(1)]
        public int TRANGTHAI { get; set; }
    }

    public class DMQUANHE
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string QUANHE { get; set; }
        public string GHICHU { get; set; }
        public int THUTU { get; set; }
        public int TRANGTHAI { get; set; }
    }

    public class DMCAPBAC
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string CAPBAC { get; set; }
        public string GHICHU { get; set; }
        public int THUTU { get; set; }
        public int TRANGTHAI { get; set; }
    }

    public class DMLOAI_BANGKHEN
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string TEN { get; set; }
        public string GHICHU { get; set; }
        public int THUTU { get; set; }
        public int TRANGTHAI { get; set; }
    }

    public class DMHUANHUYCHUONG
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string TEN { get; set; }
        public string GHICHU { get; set; }
        public int THUTU { get; set; }
        public int TRANGTHAI { get; set; }
    }

    public class DMDANHHIEU
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string TEN { get; set; }
        public string GHICHU { get; set; }
        public int THUTU { get; set; }
        public int TRANGTHAI { get; set; }
    }
}
