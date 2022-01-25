import { NgModule } from '@angular/core';
import { TaskService } from './service.service'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { FetchTaskComponent } from './fetch-task.component';
import { AddTaskComponent } from './add-task.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { BrowserModule } from '@angular/platform-browser';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    FetchTaskComponent,
    AddTaskComponent,
    NavMenuComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'fetch-task', component: FetchTaskComponent },
      { path: 'register-task', component: AddTaskComponent },
      { path: 'task/edit/:id', component: AddTaskComponent },
      { path: 'task/delete/:id', component: AddTaskComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule{
}
