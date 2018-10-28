using Boootcamp20.BaseContext;
using Boootcamp20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boootcamp20
{
    class Program
    {
        public static void Main(string[] args)
        {
            Program call = new Program();
            call.deleteItem();
            //call.jual();
            Console.Read();

        }
        MyContext _context = new MyContext();
        Supplier supplier = new Supplier();
        Item item = new Item();
        DetailPenjualan detail = new DetailPenjualan();
        Penjualan penjualan = new Penjualan();

        //region supplier
        public void insertSupplier()
        {
            Console.Write("Insert Your Supplier Name : ");
            string Name = Console.ReadLine();
            supplier.Name = Name;
            supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;
            try
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
            }
        }

        public void updateSupplier()
        {
            Console.Write("Masukan id : ");
            int Id = Convert.ToInt16(Console.ReadLine());
            var supplier = GetById(Id);
            if (supplier != null)
            {
                Console.Write("Insert Your Supplier Name : ");
                string Name = Console.ReadLine();
                supplier.Name = Name;
                supplier.UpdateDate = DateTimeOffset.Now.LocalDateTime;
                _context.Entry(supplier).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                Console.Write("Your Id Isn't Registered Yet");
            }
        }

        public Supplier GetById(int id)
        {
            try
            {
                var getid = _context.Suppliers.Find(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
            }
            return _context.Suppliers.Find(id);  
        }

        public void insertItem()
        {
            Console.Write("Insert Your Item Name : ");
            string Name = Console.ReadLine();
            Console.Write("Insert Your Item Price : ");
            int Price = Convert.ToInt16(Console.ReadLine());
            Console.Write("Insert Your Item Stok : ");
            int Stock = Convert.ToInt16(Console.ReadLine());
            Console.Write("Insert Your Supplier Id : ");
            int Supplier_Id = Convert.ToInt16(Console.ReadLine());
            var supplier = GetById(Supplier_Id);
            if (supplier != null)
            {
                item.Name = Name;
                item.Price = Price;
                item.Stock = Stock;
                item.Suppliers = supplier;
                item.CreateDate = DateTime.Now;
                _context.Items.Add(item);
                try
                {
                    _context.SaveChanges();
                } catch(Exception ex)
                {
                    Console.Write(ex.InnerException);
                }
                
            }
            else
            {
                Console.Write("Your Id Item Isn't Registered Yet");
            }
        }
        public void updateItem()
        {
            Console.Write("Insert Item Id : ");
            int Id = Convert.ToInt16(Console.ReadLine());
            var item = GetByIdItem(Id);
            if (item != null)
            {
                Console.Write("Insert Your Item Name : ");
                string Name = Console.ReadLine();
                Console.Write("Insert Your Item Price : ");
                int Price = Convert.ToInt16(Console.ReadLine());
                Console.Write("Insert Your Item Stok : ");
                int Stock = Convert.ToInt16(Console.ReadLine());
                Console.Write("Insert Your Supplier Id : ");
                int Supplier_Id = Convert.ToInt16(Console.ReadLine());
                var supplier = GetById(Supplier_Id);
                if (supplier != null)
                {
                    item.Name = Name;
                    item.Price = Price;
                    item.Stock = Stock;
                    item.Suppliers = supplier;
                    item.UpdateDate = DateTime.Now;
                    _context.Entry(supplier).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                else
                {
                    Console.Write("Your Id Supplier Isn't Registered Yet");
                }
            }
            else
            {
                Console.Write("Your Id Item Isn't Registered Yet");
            }
        }
        public void deleteItem()
        {
            Console.Write("Insert Your Item Id : ");
            int Id = Convert.ToInt16(Console.ReadLine());
            var itemz = GetByIdItem(Id);
            if (itemz != null)
            {
                item.DeleteDate = DateTime.Now;
                item.isDelete = true;
                _context.Entry(itemz).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                Console.Write("Your Id Item Isn't Registered Yet");
            }
        }
        public void retrieveItem()
        {
            var retrieve = _context.Items.Include("Suppliers").Where(x => x.isDelete == false).ToList();
            foreach (var value in retrieve)
            {
                Console.WriteLine("Id : " + value.Id);
                Console.WriteLine("Name : " + value.Name);
                Console.WriteLine("Price : " + value.Price);
                Console.WriteLine("Stock : " + value.Stock);
                Console.WriteLine("Supplier Name : " + value.Suppliers.Name);
                Console.WriteLine("Create Date : " + value.CreateDate);
                Console.WriteLine("Update Date : " + value.UpdateDate);
                Console.WriteLine("Delete Date : " + value.DeleteDate);
                Console.WriteLine("---------------------------------------------");
            }
        }
        public Item GetByIdItem(int id)
        {
            //try
            //{
            //    var getid = _context.Items.Find(id);
            //}
            //catch (Exception ex)
            //{
            //    Console.Write(ex.InnerException);
            //}
            return _context.Items.Find(id);
        }

        // penjualan
        public void jual()
        {
            Console.Write("Masukan jumlah barang yang dibeli : ");
            int JumlahBarang = Convert.ToInt16(Console.ReadLine());
            int totalpenjualan = 0;
            for (int i = 1; i <= JumlahBarang; i = i + 1)
            {
                Console.Write("Insert Your Item Id : ");
                int Id = Convert.ToInt16(Console.ReadLine());
                Console.Write("Insert Your Qyt Item : ");
                int Qyt = Convert.ToInt16(Console.ReadLine());
                var IdItem = GetByIdItem(Id);
                totalpenjualan = totalpenjualan + (Qyt * IdItem.Price);
                int StockItem = IdItem.Stock - Qyt;

                penjualan.Total = totalpenjualan;
                item.Stock = StockItem;
                detail.Qyt = Qyt;
                detail.Price = IdItem.Price;
                detail.Total = Qyt * IdItem.Price;
                detail.Items = item;
                detail.Penjualann = penjualan;

                _context.Penjualann.Add(penjualan);
                _context.Entry(item).State = EntityState.Modified;
                _context.Details.Add(detail);
                _context.SaveChanges();
            }
            Console.Write("Total " + totalpenjualan);
        }
    }
}