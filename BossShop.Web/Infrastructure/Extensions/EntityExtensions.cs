using BOSS.Model.Models;
using BossShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BossShop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            post.Id = postViewModel.Id;
            post.Name = postViewModel.Name;
            post.Alias = postViewModel.Alias;
            post.CategoryId = postViewModel.CategoryId;
            post.ViewCount = postViewModel.ViewCount;
            post.Description = postViewModel.Description;
            post.Content = postViewModel.Content;
            post.Image = postViewModel.Image;
            post.HomeFlag = postViewModel.HomeFlag;
            post.HotFlag = postViewModel.HotFlag;
            post.CreatedDate = postViewModel.CreatedDate;
            post.CreatedBy = postViewModel.CreatedBy;
            post.UpdatedDate = postViewModel.UpdatedDate;
            post.UpdatedBy = postViewModel.UpdatedBy;
            post.MetaKeyword = postViewModel.MetaKeyword;
            post.MetaDescription = postViewModel.MetaDescription;
            post.Status = postViewModel.Status;
        }
        public static void UpdateProduct(this Product product, ProductViewModel productViewModel)
        {
            product.Id = productViewModel.Id;
            product.Name = productViewModel.Name;
            product.Alias = productViewModel.Alias;
            product.CategoryId = productViewModel.CategoryId;
            product.PromotionPrice = productViewModel.PromotionPrice;
            product.Warranty = productViewModel.Warranty;
            product.Price = productViewModel.Price;
            product.ParentId = productViewModel.ParentId;
            product.DisplayOrder = productViewModel.DisplayOrder;
            product.Description = productViewModel.Description;
            product.Image = productViewModel.Image;
            product.HomeFlag = productViewModel.HomeFlag;
            product.CreatedDate = productViewModel.CreatedDate;
            product.CreatedBy = productViewModel.CreatedBy;
            product.UpdatedDate = productViewModel.UpdatedDate;
            product.UpdatedBy = productViewModel.UpdatedBy;
            product.MetaKeyword = productViewModel.MetaKeyword;
            product.MetaDescription = productViewModel.MetaDescription;
            product.Status = productViewModel.Status;
        }

        public static void UpdateMenu(this Menu menu, MenuViewModel menuViewModel)
        {
            menu.Id = menuViewModel.Id;
            menu.Name = menuViewModel.Name;
            menu.URL = menuViewModel.URL;
            menu.Status = menuViewModel.Status;
            menu.GroupID = menuViewModel.GroupID;
        }
        public static void UpdateTag(this Tag tag, TagViewModel tagVm)
        {
            tag.Id = tagVm.Id;
            tag.Name = tagVm.Name;
            tag.Type = tagVm.Type;
        }

        public static void UpdateOrder(this Order order, OrderViewModel orderVm)
        {
            order.Id = orderVm.Id;
            order.CustomerAdderss = orderVm.CustomerAdderss;
            order.CustomerName = orderVm.CustomerName;
            order.CustomerMobile = orderVm.CustomerMobile;
            order.CustomerMessage = orderVm.CustomerMessage;
            order.CustomerId = orderVm.CustomerId;
            order.PaymentMethod = orderVm.PaymentMethod;
            order.CreatedDate = orderVm.CreatedDate;
            order.CreatedBy = orderVm.CreatedBy;
            order.PaymentStatus = orderVm.PaymentStatus;
            order.Status = orderVm.Status;
        }
        
    }
}