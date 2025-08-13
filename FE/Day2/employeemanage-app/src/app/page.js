import Image from "next/image";
import styles from "./page.module.css";
import 'bootstrap/dist/css/bootstrap.css'

import Login from "./components/Login/Login";

export default function Home() {
  return (
    <div className={styles.page}>
        <Login/>
    </div>
  );
}
