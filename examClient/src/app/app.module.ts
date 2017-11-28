import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { ExamsComponent } from './exams/exams.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { ExamStatusService } from './exam-status.service';


@NgModule({
  declarations: [
    AppComponent,
    ExamsComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [ExamStatusService],
  bootstrap: [AppComponent]
})
export class AppModule { }
