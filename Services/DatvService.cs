using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Datvs;

namespace WebApi.Services
{
    public class DatvService : IDatvService
    {
        private DatvContext _context;
        private readonly IMapper _mapper;

        public DatvService(
            DatvContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Datv> GetAll()
        {
            return _context.Datvs;
        }

        public Datv GetById(int id)
        {
            return getDatv(id);
        }

        public void Create(CreateRequest model)
        {
            // validate
            if (_context.Datvs.Any(x => x.Email == model.Email))
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // map model to new object
            var datv = _mapper.Map<Datv>(model);

            // save
            _context.Datvs.Add(datv);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var datv = getDatv(id);

            // validate
            if (model.Email != datv.Email && _context.Datvs.Any(x => x.Email == model.Email))
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // copy model and save
            _mapper.Map(model, datv);
            _context.Datvs.Update(datv);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var datv = getDatv(id);
            _context.Datvs.Remove(datv);
            _context.SaveChanges();
        }

        // helper methods

        private Datv getDatv(int id)
        {
            var datv = _context.Datvs.Find(id);
            if (datv == null) throw new KeyNotFoundException("User not found");
            return datv;
        }
    }
}
