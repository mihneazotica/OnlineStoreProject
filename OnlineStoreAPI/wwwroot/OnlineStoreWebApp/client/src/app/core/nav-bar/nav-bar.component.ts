import { Component, OnInit } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  items:NbMenuItem[] = [
    {
      title: 'Home',
      icon: 'home-outline',
      link: '/home',
      home: true,
    },
    {
      title: 'Products',
      icon: 'shopping-cart-outline',
      link: '/products',
    },
    {
      title: 'Features',
      icon: 'keypad-outline',
      link: '/features',
    },
    {
      title: 'Support',
      icon: 'headphones-outline',
      link: '/support',
    },
    {
      title: 'Pricing',
      icon: 'credit-card-outline',
      link: '/pricing',
    }
  ];

}
