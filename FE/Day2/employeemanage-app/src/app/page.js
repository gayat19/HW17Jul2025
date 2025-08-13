import Image from "next/image";
import styles from "./page.module.css";
import 'bootstrap/dist/css/bootstrap.css'

import Login from "./login/page";
import NavBar from "./navbar";

export default function Home() {
  return (
    <div className={styles.page}>
       <NavBar/>
    </div>
  );
}
