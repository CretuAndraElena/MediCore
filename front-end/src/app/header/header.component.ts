import {Component, EventEmitter, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

   @Output() loadLoginPage: EventEmitter<boolean> = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  public toLoginPage(): void {
    console.log('good');
    this.loadLoginPage.emit(true);
  }

}
