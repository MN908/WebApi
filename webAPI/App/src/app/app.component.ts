import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Jobrequest } from '../Model/jobrequest';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  constructor(jobrequest: Jobrequest) {

  }

  public jobrequest: Jobrequest = new Jobrequest;
}
