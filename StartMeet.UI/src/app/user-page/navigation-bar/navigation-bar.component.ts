import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent implements OnInit {

  userDetails;

  constructor(private router:Router , private service:UserService ) { }

  ngOnInit(): void {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      }
    );
  }

  onLogOut(){
    localStorage.removeItem('token');
    this.router.navigate(['/home']);
  }
}
