import { Routes } from '@angular/router';
import { HomeComponent } from './public/home/home.component';
import { PublicComponent } from './public/public.component';
import { PageNotFoundComponent } from './public/page-not-found/page-not-found.component';
import { AdminComponent } from './admin/admin.component';
import { DashboardComponent } from './admin/views/dashboard/dashboard.component';

export const routes: Routes = [
    {
        path:"",
        component:PublicComponent
    },
    {
        path:"home",
        component:HomeComponent
    },
    {
        path: "admin",
        component: AdminComponent,
        loadChildren: () => import('./admin/admin.routes').then((m) => m.adminRoutes),
      },
    {
        path:"**",
        component:PageNotFoundComponent
    }
];
