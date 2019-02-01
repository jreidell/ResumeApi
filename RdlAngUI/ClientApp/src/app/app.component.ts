import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services';
import { Globals } from './_models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit {

  constructor(private auth: AuthService, private globals: Globals) {  }

  async getTokenData() {
    this.auth.getToken().subscribe(
      data => this.globals.token = data.access_token,
      err => console.log(err),
      () => console.log('got token!')
    );
  }

  ngOnInit() {
    this.getTokenData();
  }

}
