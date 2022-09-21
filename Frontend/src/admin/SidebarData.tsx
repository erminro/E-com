import React from 'react';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import * as IoIcons from 'react-icons/io';

export const SidebarData = [
  {
    title: 'Home',
    path: '/admin',
    icon: <AiIcons.AiFillHome />,
    cName: 'side-text'
  },
  {
    title: 'Delete Products',
    path: '/deleteproducts',
    icon: <AiIcons.AiFillCloseCircle />,
    cName: 'side-text'
  },
  {
    title: 'Add Products',
    path: '/addproducts',
    icon: <FaIcons.FaCartPlus />,
    cName: 'side-text'
  },
  {
    title: 'Update Products',
    path: '/updateproducts',
    icon: <IoIcons.IoIosPaper />,
    cName: 'side-text'
  },
];