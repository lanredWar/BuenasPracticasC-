
        List<string> TaskList = new List<string>();

            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        
        /// <summary>
        /// Show the options for Task 1. Nueva tarea,2. Remover tarea,3. Tareas pendientes,4. Salir
        /// </summary>
        /// <returns>Returns option selected by user</returns>
        int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            string choseOption = Console.ReadLine();
            return Convert.ToInt32(choseOption);
        }

        void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                ShowMenuTaskList();

                string choseOption = Console.ReadLine();

                // Remove one position because the array starts in 0 
                int indexToRemove = Convert.ToInt32(choseOption) - 1;
                
                if(indexToRemove > (TaskList.Count -1) || indexToRemove < 0)
                {
                    System.Console.WriteLine("Numero de tarea seleccionado no es valido");
                }
                else
                {
                    if(indexToRemove > -1 && TaskList.Count > 0)
                    {
                        string taskToRemove = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea {taskToRemove} eliminada");
                    }
                }
            }
            catch (Exception)
            {
                System.Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string newTask = Console.ReadLine();
                if(newTask != "" && newTask != null)
                {
                    TaskList.Add(newTask);
                    Console.WriteLine(" - Nueva Tarea registrada - ");
                }else{
                    System.Console.WriteLine("Debe colocar un nombre a la tarea");
                }
            }
            catch (Exception)
            {
                System.Console.WriteLine("Ha ocurrido un error al ingresar la tarea");
            }
        }

        void ShowMenuTaskList()
        {
            if (TaskList?.Count > 0)
            {
                Console.WriteLine("----------------------------------------");
                int currentTask = 1;
                TaskList.ForEach(p => Console.WriteLine($"{currentTask++} . {p}"));
                
                Console.WriteLine("----------------------------------------");
            } 
            else
            {
                Console.WriteLine("No hay tareas por realizar");
            }
        }
    
    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
