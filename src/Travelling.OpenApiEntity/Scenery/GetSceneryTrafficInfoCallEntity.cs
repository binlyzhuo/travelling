using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.TC;

namespace Travelling.OpenApiEntity.Scenery
{
    public class GetSceneryTrafficInfoCallEntity : TongChengBaseCallEntity
    {
        public int SceneryId { set; get; }
    }
}
