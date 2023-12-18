import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LiveComponent } from './pages/live/live.component';
import { HistoryComponent } from './pages/history/history.component';
import { PointTableComponent } from './pages/point-table/point-table.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';

export const routes: Routes = [
    {
        path:"home",
        component: HomeComponent
    },
    {
        path:"live",
        component: LiveComponent
    },
    {
        path:"history",
        component: HistoryComponent
    },
    {
        path:"point-table",
        component: PointTableComponent
    },
    {
        path:"**",
        component: PageNotFoundComponent
    },
];
