using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentController.Controllers;
public class StudentController : Controller
{
    static List<Student> students = new List<Student>(){
        new Student{Id = 1, Name = "Alex", Age = 21},
        new Student{Id = 2, Name = "John Smith", Age = 42}
    };

    public IActionResult ListStudents(){
        return View(students);
    }

    public IActionResult AddStudent(){
        return View();
    }

    [HttpPost]
    public IActionResult AddStudent(Student model){
        if(ModelState.IsValid){
            if(students.Count == 0){
                model.Id = 1;
            } else {
                model.Id = students.Max(i => i.Id) + 1;
            }
            students.Add(model);
            return RedirectToAction("ListStudents");
        }
        return View();
    }

    public IActionResult Edit(int Id){
        var student = students.Find(i => i.Id == Id);
        if(student == null){
            return NotFound();
        }
        return View(student);
    }

    [HttpPost]
    public IActionResult Edit(Student model){
        if(ModelState.IsValid){
            foreach(var i in students){
                if(i.Id == model.Id){
                    i.Name = model.Name;
                    i.Age = model.Age;
                    return RedirectToAction("ListStudents");
                }
            }
        }
        return View();
    }

    public IActionResult Delete(int Id){
        var student = students.Find(i => i.Id == Id);
        if(student == null){
            return NotFound();
        }
        return View(student);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int Id){
        foreach(var i in students){
            if(i.Id == Id){
                students.Remove(i);
                return RedirectToAction("ListStudents");
            }
        }
        return View();
    }
}