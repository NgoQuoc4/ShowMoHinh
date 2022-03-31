using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopMoHinh.Models
{
    public class cartItem
    {
        private SanPham sanPham;
        private int quantity;

        public SanPham SanPham { get => sanPham; set => sanPham = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}