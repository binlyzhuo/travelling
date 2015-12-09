using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel.Dto.Ticket;

namespace Travelling.ViewModel.Ticket
{
    public class SceneryTicketOrderSearchResult:JsonViewResult
    {
        public SceneryTicketOrder TicketOrder { set; get; }
    }
}
