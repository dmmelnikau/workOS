import { Component } from '@angular/core';
import { TaskService } from './service.service';

@Component({
  selector: 'app-fetch-task',
  templateUrl: './fetch-task.component.html'
})

export class FetchTaskComponent {

  public empList: TaskData[];

  constructor(private _taskService: TaskService) {
    this.getTasks();
  }

  getTasks() {
    this._taskService.getTasks().subscribe(
      (data: any) => this.empList = data
    );
  }


}
interface TaskData{
  id: number;
  name: string;
  description: string;
  visit: string;
}
