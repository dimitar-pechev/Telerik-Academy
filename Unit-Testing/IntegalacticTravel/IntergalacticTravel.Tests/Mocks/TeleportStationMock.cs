using System.Collections.Generic;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Tests.Mocks
{
    public class TeleportStationMock : TeleportStation
    {
        public TeleportStationMock(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location) : base(owner, galacticMap, location)
        {
        }

        public IBusinessOwner Owner
        {
            get
            {
                return base.owner;
            }
        }

        public IEnumerable<IPath> GalacticMap
        {
            get
            {
                return base.galacticMap;
            }
        }

        public ILocation Location
        {
            get
            {
                return base.location;
            }
        }

        public IResources Resources
        {
            get
            {
                return base.resources;
            }
        }
    }
}
