using NHibernate;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Service.Controllers
{

    public class ValuesController : ApiController
    {
        private DAL _dal;
        public ValuesController(DAL dal)
        {
            _dal = dal;
        }
        /*~ValuesController()
        {
            _dal.ClosSession();
        }*/
        public IList<Movie> GetAllMovies()
        {

            IList<Movie> movies = new List<Movie>();

            movies = _dal.GetSession().CreateCriteria<Movie>().List<Movie>();
            return movies;

        }

        public HttpResponseMessage GetMovieById(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            Movie movie = new Movie();
            using (ISession session = NhibernateSession.OpenSession())
            {
                movie = session.Get<Movie>(id);
                JavaScriptSerializer js = new JavaScriptSerializer();
                response.Content = new StringContent(js.Serialize(movie));
                return response;
            }
        }

        public void PostUpdatemovie(Movie movie)
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                session.Update(movie);
                session.Flush();
            }
        }

    }
}
