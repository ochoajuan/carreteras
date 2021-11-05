using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carreteras.Server.Entidades.Respuesta;
using carreteras.Server.Entidades.Request;
using carreteras.Server.Entidades;

namespace carreteras.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        public IActionResult Get()
        {
            Respuesta<List<Categoria>> oResp = new Respuesta<List<Categoria>>();

            try
            {
                using (carreterasContext db = new carreterasContext())
                {
                    var listaCategorias = db.Categorias.ToList();

                    oResp.Ok = 1;
                    oResp.Data = listaCategorias;
                }
            } catch (Exception ex)
            {
                oResp.Mensaje = ex.Message;
            }



            return Ok(oResp);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Respuesta<Categoria> oResp = new Respuesta<Categoria>();

            try
            {
                using (carreterasContext db = new carreterasContext())
                {
                    var listaCategorias = db.Categorias.Find(Convert.ToInt64(Id));

                    oResp.Ok = 1;
                    oResp.Data = listaCategorias;
                }
            }
            catch (Exception ex)
            {
                oResp.Mensaje = ex.Message;
            }



            return Ok(oResp);
        }

        [HttpPost]
        public IActionResult Add(CategoriaRequest cat)
        {
            Respuesta<object> oResp = new Respuesta<object>();

            try
            {
                using (carreterasContext db = new carreterasContext())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = cat.Id;
                    categoria.NombreCategoria = cat.NombreCategoria;
                    db.Categorias.Add(categoria);
                    db.SaveChanges();

                    oResp.Ok = 1;

                }
            }
            catch (Exception ex)
            {
                oResp.Mensaje = ex.Message;
            }



            return Ok(oResp);
        }

        [HttpPut]
        public IActionResult Edit(CategoriaRequest cat)
        {
            Respuesta<object> oResp = new Respuesta<object>();

            try
            {
                using (carreterasContext db = new carreterasContext())
                {
                    Categoria categoria = db.Categorias.Find(Convert.ToInt64(cat.Id));
                    categoria.Id = cat.Id;
                    categoria.NombreCategoria = cat.NombreCategoria;
                    db.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    oResp.Ok = 1;

                }
            }
            catch (Exception ex)
            {
                oResp.Mensaje = ex.Message;
            }



            return Ok(oResp);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta<object> oResp = new Respuesta<object>();

            try
            {
                using (carreterasContext db = new carreterasContext())
                {
                    Categoria categoria = db.Categorias.Find(Convert.ToInt64(Id));
                    db.Remove(categoria);
                    db.SaveChanges();

                    oResp.Ok = 1;

                }
            }
            catch (Exception ex)
            {
                oResp.Mensaje = ex.Message;
            }



            return Ok(oResp);
        }
    }
}
