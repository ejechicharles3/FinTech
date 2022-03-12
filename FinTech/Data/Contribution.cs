using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Data
{
    public class Contribution
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey(nameof(ContributionType))]
        public int ContributionTypeId { get; set; }
        public ContributionType ContributionType { get; set; }


        [ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }


        //public static decimal Sum(List<decimal> d)
        //{
        //    var a = 0m;
        //    foreach (var item in d) 
        //    {
        //        a += item;
        //    }
        //    return a;
        //}

//        {
//    "id": 1,
//    "contributionType": {
//        "id": 1,
//        "contributions": [],
//        "name": "Savings"
//    },
//    "contributionTypes": null,
//    "date": "2022-02-26T07:07:48.8767046",
//    "time": "2022-02-26T07:07:48.9055181",
//    "amount": 1000.00,
//    "contributionTypeId": 1
//}
    }
}
