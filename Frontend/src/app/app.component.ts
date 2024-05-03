import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  ViewChild,
} from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements AfterViewInit {

  title = 'Inventory Management System';
  @ViewChild(MatSidenav) sideNav!: MatSidenav;

  constructor(
    private observer: BreakpointObserver,
    private cdr: ChangeDetectorRef
  ) {}
  ngAfterViewInit(): void {
    this.sideNav.opened = true;
    this.observer.observe(['(max-width:787px)']).subscribe((res) => {
      if (res?.matches) {
        this.sideNav.mode = 'over';
        this.sideNav.close();
      } else {
        this.sideNav.mode = 'side';
        this.sideNav.open();
      }
    });
    this.cdr.detectChanges();
  }

  action(menuItem: string) {
    switch (menuItem) {
      case 'employee': {
        console.log('route to employee module');
        break;
      }
      case 'device': {
        console.log('route to device module');
        break;
      }
      default: {
        //statements;
        break;
      }
    }
  }

  sideNavToggle(arg0: string) {
    switch (arg0) {
      case 'menu': {
        console.log('clicked menu');
        break;
      }
      case 'close': {
        console.log('clicked closed');
        break;
      }
      default: {
        //statements;
        break;
      }
    }
    }
}
