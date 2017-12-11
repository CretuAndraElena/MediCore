import {Component, EventEmitter, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @Output() loadRegisterPage: EventEmitter<boolean> = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  goToRegisterPage(): void {
    this.loadRegisterPage.emit(true);
  }

}
