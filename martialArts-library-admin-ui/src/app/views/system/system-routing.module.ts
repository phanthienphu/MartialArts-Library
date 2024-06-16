import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {UserComponent} from './user/user.component'
import { AuthGuard } from 'src/app/shared/auth.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo:'user',
    pathMatch:'full',
    canActivate:[AuthGuard]
  },
  {
    path: 'User',
    component: UserComponent,
    data: {
      title: 'User'
    },
    canActivate:[AuthGuard]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class systemRoutingModule {
}
