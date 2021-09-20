using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ToDoDto:IDto
    {
        public int TodoId { get; set; }
        public int PriorityId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool P1 { get; set; }
        public string P2 {  get; set; }
        public string P3 {  get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate {  get; set;}
    }
}
