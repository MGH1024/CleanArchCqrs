import create from 'zustand';
import {persist} from 'zustand/middleware';


let appStore: any = (set:any) => ({
    doOpen: true,
    updateOpen: (doOpen: boolean) => set((state:any) => ({doOpen: doOpen})),
});

appStore = persist(appStore, {name: "my_app_store"});

export const useAppStore = create(appStore);