using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using K22CNT3_DinhQuocDat_Buoi4.Models;

namespace K22CNT3_DinhQuocDat_Buoi4.Bussiness
{
    public class DQD_ShoppingCart
    {
        public List<DQDCartItem> Items { get; set; }

        public DQD_ShoppingCart()
        {
            Items = new List<DQDCartItem>();
        }

        // Chuc nang them san pham vao gio hang
        public void AddToCart(DQDCartItem item)
        {
            var existingItem = Items.FirstOrDefault(x => x.ID == item.ID);
            if (existingItem != null)
            {
                existingItem.SoLuongMua += item.SoLuongMua;
            }
            else
            {
                Items.Add(item);
            }
        }

        // Xóa sản phẩm trong giỏ hàng
        public void RemoveCartItem(int id)
        {
            var itemToRemove = Items.FirstOrDefault(x => x.ID == id);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        // Tính tổng trị giá của hóa đơn
        public float GetTongThanhTien()
        {
            return Items.Sum(x => x.SoLuongMua * x.DonGiaMua);
        }

        // Cập nhật Shopping cart
        public void UpdateFromCart(int id, int qty)
        {
            var existingItem = Items.FirstOrDefault(x => x.ID == id);
            if (existingItem != null)
            {
                existingItem.SoLuongMua = qty;
            }
        }
    }

}