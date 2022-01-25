import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl+ 'api/Task/';
  }

  getTasks() {
    return this._http.get(this.myAppUrl + 'Index').
      pipe(map(
        response => {
          return response;
        }));
  }

  getTaskById(id: number) {
    return this._http.get(this.myAppUrl + "Details/" + id).
      pipe(map(
        response => {
          return response;
        }));
  }

  saveTask(task:TaskData) {
    return this._http.post(this.myAppUrl + 'Create', task).
      pipe(map(
        response => {
          return response;
        }));
  }

  updateTask(task:TaskData) {
    return this._http.put(this.myAppUrl + 'Edit', task)
      .pipe(map(
        response => {
          return response;
        }));
  }

  deleteTask(task:TaskData) {
    return this._http.delete(this.myAppUrl + "Delete" + task)
      .pipe(map(
        response => {
          return response;
        }));
  }
}
