import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from '../student';
import { ExamStatusService } from '../exam-status.service';

@Component({
  selector: 'app-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.css']
})
export class ExamsComponent implements OnInit {
  exams: object;

  constructor(private http: HttpClient, private statusService: ExamStatusService) { }

  getStudentLogged(): Student {
    return this.statusService.getStudentLogged();
  }

  enroll(exam): void {
    console.log(exam);
    let url = 'http://localhost:5000/api/exams/';
    url = url + exam.id + '/students';
    this.http.put<Student>(url, {'id': this.getStudentLogged().id}).subscribe(data => {
      this.statusService.getStudentLogged().examReferenceId = exam.id;
    });
  }

  unenroll(exam): void {
    console.log(exam);
    let url = 'http://localhost:5000/api/exams/';
    url = url + exam.id + '/students/' + this.getStudentLogged().id;
    this.http.delete<Student>(url).subscribe(data => {
      this.statusService.getStudentLogged().examReferenceId = null;
    });
  }

  ngOnInit() {
    this.http.get('http://localhost:5000/api/exams').subscribe(data => {
      this.exams = data;
      console.log(data);
    });
  }
}
