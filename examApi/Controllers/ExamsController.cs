using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using examApi.Models;
using System.Linq;

/*
Questo controller espone le API della risorsa Exam, definita nel package Models.
 */
namespace ExamApi.Controllers
{
    /*
    Definisco il routing per raggiungere le mia risorsa. Utilizzo il nome del controller come nome della risorsa.
     */
    [Route("api/[Controller]")]
    public class ExamsController : Controller
    {
        private readonly ExamContext _context;

        /* 
        Inizializzo il db in_memory con alcuni esami di esempio. 
        */
        public ExamsController(ExamContext context)
        {
            _context = context;
            if (_context.ExamItems.Count() == 0)
            {
                _context.ExamItems.Add(new Exam { 
                    professor = "Zanini Chiara" ,
                    code = "23ACIPL",
                    title = "Analisi complessa ed e lementi di statistica (AA-ZZ)",
                    location = "Torino - LAIB5 - Lab. Inf. di Base - Corso Duca",
                    date = "08/02/2018",
                    deadLineSubscription = "31/01/2018",
                    type = "scritto"});
                _context.ExamItems.Add(new Exam { 
                    professor = "Bibbona Enrico" ,
                    code = "02NNDLX",
                    title = "Analisi Matematica II",
                    location = "Torino - 1B - AULA Corso Duca",
                    date = "08/02/2018",
                    deadLineSubscription = "06/02/2018",
                    type = "scritto"});
                _context.ExamItems.Add(new Exam { 
                    professor = "Salzone Luca" ,
                    code = "01ANXLD",
                    title = "Analisi Matematica I",
                    location = "Torino - 1A - AULA Corso Settembrini",
                    date = "08/02/2018",
                    deadLineSubscription = "06/02/2018",
                    type = "scritto"});
                _context.SaveChanges();
            }

            if (_context.StudentItems.Count() == 0)
            {
                _context.StudentItems.Add(new Student {
                    name= "Mario",
                    surname= "Rossi",
                    serialNumber = "123",
                    password = "123",
                    examReferenceId = null,
                    username = "mario.rossi"
                });
                _context.StudentItems.Add(new Student {
                    name= "Alberto",
                    surname= "Bianchi",
                    serialNumber = "123",
                    password = "123",
                    examReferenceId = null,
                    username = "alberto.bianchi"
                });
                _context.StudentItems.Add(new Student {
                    name= "Giuseppe",
                    surname= "Verdi",
                    serialNumber = "123",
                    password = "123",
                    examReferenceId = null,
                    username = "giuseppe.verdi"
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Exam> getAll()
        {
            return _context.ExamItems.ToList();
        }

        [HttpGet("{id}", Name = "GetExam")]
        public IActionResult GetById(long id)
        {
            Exam item = _context.ExamItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult create([FromBody] Exam item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.ExamItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetExam", new { id = item.Id }, item);
        }

        [HttpPost("login")]
        public IActionResult login([FromBody] Student item)
        {
            if (item == null || item.username == null || item.password == null)
            {
                return BadRequest();
            }
            string userName = item.username;
            string password = item.password;
            var student = _context.StudentItems.Where(t => t.username == userName &&  t.password == password);
            if(student.Count() == 0) return NotFound();
            return Ok(student.Single());
        }

        [HttpPut("{id}")]
        public IActionResult update(long id, [FromBody] Exam item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var exam = _context.ExamItems.FirstOrDefault(t => t.Id == id);
            if (exam == null)
            {
                return NotFound();
            }

            exam.professor = item.professor;
            exam.code = item.code;
            exam.date = item.date;
            exam.deadLineSubscription = item.deadLineSubscription;
            exam.title = item.title;

            _context.ExamItems.Update(exam);
            _context.SaveChanges();
            return new NoContentResult();
        }

        //--------------- STUDENTS -------------
        [HttpGet("availableStudents")]
        public IEnumerable<Student> availableStudents()
        {
            List<Student> students = _context.StudentItems.ToList();
            return students;
        }

        [HttpGet("{id}/students")]
        public IEnumerable<Student> getExamStudents(long id)
        {
            List<Student> students = _context.StudentItems.Where(t => t.examReferenceId == id ).ToList();
            return students;
        }

        [HttpPut("{id}/students")]
        public IActionResult addStudent(long id,[FromBody] Student item)
        {
            var student = _context.StudentItems.FirstOrDefault(t => t.Id == item.Id);
            if(student == null)
            {
                return NotFound();
            }
            student.examReferenceId = id;
            _context.StudentItems.Update(student);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}/students/{studentId}")]
        public IActionResult removeStudent(long id,long studentId)
        {
            var student = _context.StudentItems.FirstOrDefault(t => t.Id == studentId);
            if(student == null)
            {
                return NotFound();
            }
            
            student.examReferenceId = null;
            _context.StudentItems.Update(student);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}