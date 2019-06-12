using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using FootballLib;
using FootballLib.Rounds;

namespace FootballMatches.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        WorldCup worldCup;
        List<Team> resultPlayOff;
        List<Match> matchesPlayOff;
        List<Team> resultOct;
        List<Match> matchesOct;
        List<Team> resultQuad;
        List<Match> matchesQuad;
        List<Match> matchesFinal;

        string[] groupID = { "A", "B", "C", "D", "E", "F", "G", "H" };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            worldCup = new WorldCup();
            worldCup.TeamProvider = new FootballLib.DataProviders.SqlProvider();
            PreRound preRound = new PreRound();
            PlayOff playOff = new PlayOff();
            OctRound octRound = new OctRound();
            QuadRound quadRound = new QuadRound();
            FinalRound finalRound = new FinalRound();

            preRound.InputTeams = worldCup.TeamList;

            playOff.InputTeams = preRound.Play();
            resultPlayOff = playOff.Play();
            matchesPlayOff = playOff.MatchList;

            octRound.InputTeams = new List<Team>(resultPlayOff);
            resultOct = octRound.Play();
            matchesOct = octRound.MatchList;

            quadRound.InputTeams = new List<Team>(resultOct);
            resultQuad = quadRound.Play();
            matchesQuad = quadRound.MatchList;

            finalRound.InputTeams = new List<Team>(resultQuad);
            Team championship = finalRound.Play()[0];
            matchesFinal = finalRound.MatchList;

            groupA.OnClick += Group_OnClick;
            groupB.OnClick += Group_OnClick;
            groupC.OnClick += Group_OnClick;
            groupD.OnClick += Group_OnClick;
            groupE.OnClick += Group_OnClick;
            groupF.OnClick += Group_OnClick;
            groupG.OnClick += Group_OnClick;
            groupH.OnClick += Group_OnClick;

            sc1.OnClick += Sc_Playoff;
            sc2.OnClick += Sc_Playoff;
            sc3.OnClick += Sc_Playoff;
            sc4.OnClick += Sc_Playoff;
            sc5.OnClick += Sc_Playoff;
            sc6.OnClick += Sc_Playoff;
            sc7.OnClick += Sc_Playoff;
            sc8.OnClick += Sc_Playoff;

            groupQuad1.OnClick += GroupQuad_OnClick;
            groupQuad2.OnClick += GroupQuad_OnClick;
            groupQuad3.OnClick += GroupQuad_OnClick;
            groupQuad4.OnClick += GroupQuad_OnClick;

            scQ1.OnClick += ScQ_OnClick;
            scQ2.OnClick += ScQ_OnClick;
            scQ3.OnClick += ScQ_OnClick;
            scQ4.OnClick += ScQ_OnClick;


        }

        private void ScQ_OnClick(SelectedTeamControl sender)
        {
            int i = int.Parse(sender.Data) - 1;
            nation1.Team = resultOct[i];
            nation2.Team = null;
            nation3.Team = null;
            nation4.Team = null;
        }

        private void GroupQuad_OnClick(GroupControl sender)
        {
            string[] oct = { "Q1", "Q2", "Q3", "Q4" };
            for(int i = 0; i < oct.Length; i++)
            {
                if(sender.Text == oct[i])
                {
                    nation1.Team = matchesOct[i].TeamA;
                    nation2.Team = matchesOct[i].TeamB;
                    nation3.Team = null;
                    nation4.Team = null;
                    dataGrid.ItemsSource = matchesOct;
                }
            }
        }

        private void Sc_Playoff(SelectedTeamControl sender)
        {
            for (int i = 0; i < groupID.Length; i++)
            {
                if (groupID[i] == sender.Data)
                {
                    nation1.Team = resultPlayOff[i];
                    nation2.Team = null;
                    nation3.Team = null;
                    nation4.Team = null;
                }
            }

        }

        private void Group_OnClick(GroupControl sender)
        {
            List<Match> matches = matchesPlayOff.Where(match => match.Tag == sender.Text).ToList();
            List<Team> team = new List<Team>();
            foreach (Match match in matches)
            {
                if (team.Find(t => t.Code == match.TeamA.Code) == null)
                {
                    team.Add(match.TeamA);
                }
                if (team.Find(t => t.Code == match.TeamB.Code) == null)
                {
                    team.Add(match.TeamB);
                }
            }
            nation1.Team = team[0];
            nation2.Team = team[1];
            nation3.Team = team[2];
            nation4.Team = team[3];

            dataGrid.ItemsSource = matches;
        }

        private void TeamControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
