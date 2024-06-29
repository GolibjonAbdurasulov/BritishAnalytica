using System;
using System.Collections.Generic;

namespace Web.Controllers.HomeModelController.HomeModelDtos;

public class HomeModelDto
{
   public string Title { get; set; }
   public string Body { get; set; }
   public List<Guid> ImageIds { get; set; }
}