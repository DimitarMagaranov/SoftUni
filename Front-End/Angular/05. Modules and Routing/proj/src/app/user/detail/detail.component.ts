import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IUser } from 'src/app/shared/interfaces';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class UserDetailComponent implements OnInit {

  public user: IUser | null = null;

  constructor(
    private activatedRoute: ActivatedRoute,
    private userService: UserService
    ) {
    // console.log(this.activatedRoute.snapshot.params);
    // this.activatedRoute.params.subscribe(console.log);
  }

  ngOnInit(): void {
    this.loadUser();
  }

  loadUser(): void {
    const id: number = this.activatedRoute.snapshot.params['id'];
    this.userService.loadUser(id).subscribe({
      next: (user) => {
        this.user = user;
      }
    })
  }

}
