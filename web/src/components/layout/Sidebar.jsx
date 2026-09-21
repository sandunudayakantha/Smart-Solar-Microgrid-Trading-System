import React from 'react';
import { NavLink } from 'react-router-dom';

export default function Sidebar() {
  // 1. FAT Backend: Get the authorized menu from localStorage
  const menuItems = JSON.parse(localStorage.getItem('menu') || '[]');

  // SVG Icons mapped to the string returned by the backend (e.g. "users", "shield")
  const Icons = {
    dashboard: (
      <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="1.6" className="w-4 h-4 opacity-85 shrink-0">
        <rect x="3" y="3" width="7" height="9" rx="1"/><rect x="14" y="3" width="7" height="5" rx="1"/><rect x="14" y="12" width="7" height="9" rx="1"/><rect x="3" y="16" width="7" height="5" rx="1"/>
      </svg>
    ),
    users: (
      <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="1.6" className="w-4 h-4 opacity-85 shrink-0">
        <circle cx="12" cy="8" r="3.2"/><path d="M4 20c1.5-4 5-6 8-6s6.5 2 8 6"/>
      </svg>
    ),
    shield: (
      <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="1.6" className="w-4 h-4 opacity-85 shrink-0">
        <rect x="3" y="4" width="18" height="16" rx="2"/><path d="M7 9h10M7 13h6"/>
      </svg>
    ),
  };

  const navItemClass = ({ isActive }) => 
    `flex items-center gap-3 px-4 py-2.5 text-sm transition-all border-l-2 ${
      isActive 
        ? 'text-white bg-slate-800/50 border-amber-500' 
        : 'text-slate-400 border-transparent hover:text-white hover:bg-slate-800/30'
    }`;

  // 3. FAT Backend: Get user details from localStorage
  const userName = localStorage.getItem('userName') || 'User';
  const userRole = localStorage.getItem('userRole') || 'Role';
  const initial = userName.charAt(0).toUpperCase();

  return (
    <aside className="w-60 bg-slate-900 border-r border-slate-800 flex flex-col h-screen sticky top-0 shrink-0">
      
      {/* Brand */}
      <div className="p-6 pb-8">
        <div className="flex items-center gap-3">
          <div className="w-8 h-8 bg-amber-500 rounded flex items-center justify-center">
            <svg viewBox="0 0 24 24" fill="none" className="w-4 h-4 text-slate-950">
              <path d="M13 2L4 14h6l-1 8 9-12h-6l1-8z" fill="currentColor"/>
            </svg>
          </div>
          <span className="text-white font-bold tracking-wide">Solara Grid</span>
        </div>
      </div>

      {/* Navigation */}
      <nav className="flex-1 overflow-y-auto pb-4">
        <div className="px-5 text-[10px] font-mono tracking-widest text-slate-500 mb-2 mt-4">ADMINISTRATION</div>
        
        {/* 2. FAT Backend: Loop over the dynamic menu items! */}
        {menuItems.map(item => (
          <NavLink to={item.path} key={item.label} className={navItemClass}>
            {Icons[item.icon]}
            {item.label}
          </NavLink>
        ))}

      </nav>

      {/* Footer / User Profile */}
      <div className="p-4 border-t border-slate-800">
        <div className="flex items-center gap-3">
          <div className="w-8 h-8 rounded-full bg-slate-800 border border-slate-700 flex items-center justify-center text-xs font-semibold text-teal-400">
            {initial}
          </div>
          <div className="leading-tight truncate">
            <div className="text-sm font-medium text-white truncate">{userName}</div>
            <div className="text-[10px] text-slate-500 font-mono truncate">{userRole}</div>
          </div>
        </div>
      </div>

    </aside>
  );
}
