//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WMS.DataLayer.Enums;
//using WMS.DataLayer.Interfaces;
//using WMS.DataLayer.Models;

//namespace WMS.DataLayer
//{
//    public class ApplicationContext<T> where T : IRecordState
//    {
//        private string _dataDir = Directory.GetParent(Directory.GetCurrentDirectory()).ToString() + "\\DataFiles";
//        private string _selectedPath { get; set; } = string.Empty;
//        private List<T> _dataList { get; set; }

//        public ApplicationContext()
//        {
//            _dataList = new List<T>();
//            Initialize();
//        }

//        private void SelectPath(Type type)
//        {
//            if (type == typeof(Order)) { _selectedPath = _dataDir + "/Orders.json"; }
//            if (type == typeof(Product)) { _selectedPath = _dataDir + "/Products.json"; }
//            if (type == typeof(Shipment)) { _selectedPath = _dataDir + "/Shipments.json"; }
//            if (type == typeof(StorageSlot)) { _selectedPath = _dataDir + "/StorageSlots.json"; }
//            if (type == typeof(Supply)) { _selectedPath = _dataDir + "/Supplies.json"; }
//            if (type == typeof(Account)) { _selectedPath = _dataDir + "/Accounts.json"; }
//        }

//        private void Initialize()
//        {
//            SelectPath(typeof(T));
//            if (!File.Exists(_selectedPath)) { return; }

//            using StreamReader reader = new(_selectedPath);
//            var data = reader.ReadToEnd();
//            _dataList = JsonConvert.DeserializeObject<List<T>>(data).Where(x => x.RecordState == RecordState.Active).ToList();
//        }

//        public List<T> All()
//        {
//            return _dataList;
//        }

//        public async Task<Guid> Add(T model)
//        {
//            model.RecordState = RecordState.Active;
//            model.Id = Guid.NewGuid();
//            model.CreatedAtUtc = DateTime.UtcNow;

//            _dataList.Add(model);

//            var data = JsonConvert.SerializeObject(_dataList, Formatting.Indented);
//            await File.WriteAllTextAsync(_selectedPath, data);

//            return model.Id;
//        }

//        public T Single(Guid Id)
//        {
//            var result = _dataList.Where(x => x.Id == Id).FirstOrDefault();

//            return result;
//        }

//        public async Task<Guid?> Update(T model)
//        {
//            var index = _dataList.FindIndex(x => x.Id == model.Id);

//            if (index == -1) { return null; }

//            _dataList[index] = model;
//            var data = JsonConvert.SerializeObject(_dataList, Formatting.Indented);
//            await File.WriteAllTextAsync(_selectedPath, data);

//            return model.Id;
//        }

//        public async Task<Guid?> Remove(Guid Id)
//        {
//            var index = _dataList.FindIndex(x => x.Id == Id);

//            if (index == -1) { return null; }

//            _dataList[index].RecordState = RecordState.Deleted;
//            var data = JsonConvert.SerializeObject(_dataList, Formatting.Indented);
//            await File.WriteAllTextAsync(_selectedPath, data);

//            return Id;
//        }
//    }
//}
