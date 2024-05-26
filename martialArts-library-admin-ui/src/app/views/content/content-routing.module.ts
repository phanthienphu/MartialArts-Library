import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {PostComponent}  from './Posts/post.component'

const routes: Routes = [
  {
    path: '',
    redirectTo:'post',
    pathMatch:'full',
  },
  {
    path: 'posts',
    component: PostComponent,
    data: {
      title: 'Posts'
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContentRoutingModule {
}
