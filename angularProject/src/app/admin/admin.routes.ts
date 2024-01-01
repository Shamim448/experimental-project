import {Routes} from '@angular/router';
import { DashboardComponent } from './views/dashboard/dashboard.component';



export const adminRoutes: Routes = [
      {
        path:'',
        title: 'Admin Dashboard',
        component: DashboardComponent      
      },
      /* {
        path:'',
        title: 'Admin Dashboard',
        redirectTo:"Dashboard",
        pathMatch: 'full',      
      }, */
      {
        title: 'Admin Dashboard',
        path: "Dashboard",
        component: DashboardComponent,
      },
];

