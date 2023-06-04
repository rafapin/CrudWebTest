import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, Renderer2 } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-users-start',
  templateUrl: './users-start.component.html',
  styleUrls: ['./users-start.component.scss'],
  animations: [
    trigger('fadeInOut', [
      state('void', style({ opacity: 0 })),
      transition(':enter, :leave', [
        animate(500)
      ])
    ])
  ]
})
export class UsersStartComponent {  
  loading: boolean = false;

  constructor(private router: Router,private renderer: Renderer2) {}

  start() {
    this.loading = true; 
    setTimeout(() => {
      this.loading = false;
      this.router.navigate(['/users']); 
    }, 3000);
  }
}
