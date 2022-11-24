import { Component, OnInit } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';
import { NbSidebarService } from '@nebular/theme';

@Component({
  selector: 'app-nav-bar-up',
  templateUrl: './nav-bar-up.component.html',
  styleUrls: ['./nav-bar-up.component.scss']
})
export class NavBarUpComponent implements OnInit {

  accountItems = [
    { title: 'Profile' },
    { title: 'Log out' },
  ];

  constructor(private sidebarService: NbSidebarService) { }

  ngOnInit(): void {
  }

  toggleCompact()
  {
   //check if sidebar is expanded or not
    if(this.sidebarService.getSidebarState('left'))
    {
    this.sidebarService.toggle(true, 'left');
    this.sidebarService.expand();}
    else
    {this.sidebarService.toggle(false, 'left');
    this.sidebarService.collapse();}
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
    }
  ];
}
