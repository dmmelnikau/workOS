import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FetchTaskComponent } from './fetch-task.component';
import { TaskService } from './service.service';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html'
})

export class AddTaskComponent implements OnInit {
  taskForm: FormGroup;
  title: string = "Create";
  id: number;
  errorMessage: any;

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
              private _taskService: TaskService, private _router: Router) {
    if (this._avRoute.snapshot.params["id"]) {
      this.id = this._avRoute.snapshot.params["id"];
    }

    this.taskForm = this._fb.group({
      id: 0,
      name: ['', [Validators.required]],
      description: ['', [Validators.required]],
      visit: ['', [Validators.required]],
    })
  }

  ngOnInit() {
    if (this.id > 0) {
      this.title = "Edit";
      this._taskService.getTaskById(this.id)
        .subscribe((response: TaskData) => {
          this.taskForm.setValue(response);
        }, error => console.error(error));
    }
  }
  save() {

    if (!this.taskForm.valid) {
      return;
    }

    if (this.title == "Create") {
      this._taskService.saveTask(this.taskForm.value)
        .subscribe((data) => {
          this._router.navigate(['/fetch-task']);
        }, error => this.errorMessage = error)
    }
    else if (this.title == "Edit") {
      this._taskService.updateTask(this.taskForm.value)
        .subscribe((data) => {
          this._router.navigate(['/fetch-task']);
        }, error => this.errorMessage = error)
    }
    else if (this.title == "Delete") {
      this._taskService.deleteTask(this.taskForm.value)
        .subscribe((data) => {
          this._router.navigate(['/fetch-task']);
        }, error => this.errorMessage = error)
    }
  }

  cancel() {
    this._router.navigate(['/fetch-task']);
  }

  get name() { return this.taskForm.get('name'); }
  get description() { return this.taskForm.get('description'); }
  get visit() { return this.taskForm.get('visit'); }
}
