using Domain.Abstract.Entity;
using Domain.Abstract.Entity.Logic;
using Domain.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Logic
{
    public class ContentLogic : IContentLogic
    {
        IContentRepository _contentRepository;
        public ContentLogic(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        //public List<IContent> GetContents()
        //{
        //    var contents = _contentRepository.GetContents();
        //    return contents;
        //}
    }
}
