import { Component, OnInit } from '@angular/core';
import { NgModel } from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import { Student } from '../student';
import { ExamStatusService } from '../exam-status.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  credential: Student = new Student(null, null, null, null, null, null, null);
  username: string = null;
  password: string = null;

  constructor(private http: HttpClient, private statusService: ExamStatusService) { }

  ngOnInit() {
  }

  logout() {
    this.statusService.setStudentLogged(null);
  }

  login() {
    this.credential.username = this.username;
    this.credential.password = this.password;
    console.log(this.credential.username);
    console.log(this.credential.password);

    this.http.post<Student>('http://localhost:5000/api/exams/login',
      {'username': this.credential.username, 'password': this.credential.password}).subscribe(data => {
      console.log(data);
      this.statusService.setStudentLogged(data);
    });
  }

  getStudentLogged(): Student {
    return this.statusService.getStudentLogged();
  }

}
