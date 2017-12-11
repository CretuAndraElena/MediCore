import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @Input() loadLoginPage = false;
  @Input() loadRegisterPage = false;

  public loadLogin(): void {
    this.loadLoginPage = true;
    this.loadRegisterPage = false;
  }

  public loadRegister(): void {
    this.loadLoginPage = false;
    this.loadRegisterPage = true;
  }
}
