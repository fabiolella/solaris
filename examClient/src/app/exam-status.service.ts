import { Injectable } from '@angular/core';
import { Student } from './student';

@Injectable()
export class ExamStatusService {
  _studentLogged: Student = null;

  constructor() { }

  getStudentLogged(): Student {
    return this._studentLogged;
  }

  setStudentLogged(student): void {
    this._studentLogged = student;
  }

}
