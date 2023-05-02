import create from 'zustand';
import {persist} from 'zustand/middleware';

let currentUser: any = (set: any) => ({
    isLogin: false,
    updateCurrentUser: (isLogin: boolean) => set((state: any) => ({isLogin: isLogin})),
});

currentUser = persist(currentUser, {name: "app-current-user"})
export const useCurrentUser = create(currentUser);

